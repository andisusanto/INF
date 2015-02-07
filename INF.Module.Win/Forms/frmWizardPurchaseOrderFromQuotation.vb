Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Public Class frmWizardPurchaseOrderFromQuotation
    Public Sub New(ByVal prmObjectSpace As XPObjectSpace, ByVal prmPurchaseOrder As PurchaseOrder)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _nestedUnitOfWork = prmObjectSpace.Session.BeginNestedUnitOfWork()
        _purchaseOrder = NestedUnitOfWork.GetNestedObject(prmPurchaseOrder)

        Dim xp As New XPCollection(Of Quotation)(NestedUnitOfWork, GroupOperator.And(New BinaryOperator("IssueDate", PurchaseOrder.TransDate, BinaryOperatorType.LessOrEqual), _
                                                                                         New BinaryOperator("ValidUntil", PurchaseOrder.TransDate, BinaryOperatorType.GreaterOrEqual)))
        Dim xpDataSource As New XPCollection(Of Quotation)(NestedUnitOfWork, False)
        For Each obj In xp
            xpDataSource.Add(obj)
        Next
        cgrDataQuotation.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "No", .FieldName = "No", .Visible = True, .VisibleIndex = 1})
        cgrDataQuotation.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "IssueDate", .FieldName = "IssueDate", .Visible = True, .VisibleIndex = 2})
        cgrDataQuotation.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "Validity", .FieldName = "Validity", .Visible = True, .VisibleIndex = 3})
        cgrDataQuotation.DataSource = xpDataSource
    End Sub
    Private _nestedUnitOfWork As NestedUnitOfWork
    Private _purchaseOrder As PurchaseOrder
    Public ReadOnly Property NestedUnitOfWork As NestedUnitOfWork
        Get
            Return _nestedUnitOfWork
        End Get
    End Property
    Public ReadOnly Property PurchaseOrder As PurchaseOrder
        Get
            Return _purchaseOrder
        End Get
    End Property

    Private Sub btnWizard_Click(sender As Object, e As EventArgs) Handles btnWizard.Click
        Try
            Dim xp As New XPCollection(Of Quotation)(NestedUnitOfWork, False)
            For Each obj In cgrDataQuotation.SelectedObjects
                xp.Add(obj)
            Next
            xp.Sorting = New SortingCollection(New SortProperty("IssueDate", DB.SortingDirection.Ascending))
            For Each obj As Quotation In xp
                obj.Details.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
                For Each objQuotationDetail In obj.Details
                    Dim objPurchaseOrderDetail As New PurchaseOrderDetail(NestedUnitOfWork)
                    objPurchaseOrderDetail.PurchaseOrder = PurchaseOrder
                    objPurchaseOrderDetail.Item = objQuotationDetail.Item
                    objPurchaseOrderDetail.PricePerUnit = objQuotationDetail.PricePerUnit
                    objPurchaseOrderDetail.Quantity = objQuotationDetail.Quantity
                Next
            Next
            NestedUnitOfWork.CommitChanges()
            Close()
        Catch ex As Exception
            NestedUnitOfWork.RollbackTransaction()
            Throw ex
        End Try
    End Sub

End Class