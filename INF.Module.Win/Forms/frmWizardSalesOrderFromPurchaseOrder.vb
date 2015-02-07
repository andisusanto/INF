Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Public Class frmWizardSalesOrderFromPurchaseOrder
    Public Sub New(ByVal prmObjectSpace As XPObjectSpace, ByVal prmSalesOrder As SalesOrder)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _nestedUnitOfWork = prmObjectSpace.Session.BeginNestedUnitOfWork()
        _salesOrder = NestedUnitOfWork.GetNestedObject(prmSalesOrder)

        Dim xp As New XPCollection(Of PurchaseOrder)(NestedUnitOfWork, GroupOperator.And(New BinaryOperator("TransDate", SalesOrder.TransDate, BinaryOperatorType.LessOrEqual), _
                                                                                     New BinaryOperator("Status", TransactionStatus.Submitted), _
                                                                                     New BinaryOperator("InvoicingOutstandingStatus", OutstandingStatus.Clear, BinaryOperatorType.NotEqual)))
        Dim xpDataSource As New XPCollection(Of PurchaseOrder)(NestedUnitOfWork, False)
        For Each obj In xp
            xpDataSource.Add(obj)
        Next
        cgrDataPurchaseOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "No", .FieldName = "No", .Visible = True, .VisibleIndex = 1})
        cgrDataPurchaseOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "Supplier", .FieldName = "Supplier.Name", .Visible = True, .VisibleIndex = 2})
        cgrDataPurchaseOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "ReferenceNo", .FieldName = "ReferenceNo", .Visible = True, .VisibleIndex = 3})
        cgrDataPurchaseOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "TransDate", .FieldName = "TransDate", .Visible = True, .VisibleIndex = 4})
        cgrDataPurchaseOrder.DataSource = xpDataSource
    End Sub
    Private _nestedUnitOfWork As NestedUnitOfWork
    Private _salesOrder As SalesOrder
    Public ReadOnly Property NestedUnitOfWork As NestedUnitOfWork
        Get
            Return _nestedUnitOfWork
        End Get
    End Property
    Public ReadOnly Property SalesOrder As SalesOrder
        Get
            Return _salesOrder
        End Get
    End Property

    Private Sub btnWizard_Click(sender As Object, e As EventArgs) Handles btnWizard.Click
        Try
            Dim xp As New XPCollection(Of PurchaseOrder)(NestedUnitOfWork, False)
            For Each obj In cgrDataPurchaseOrder.SelectedObjects
                xp.Add(obj)
            Next
            xp.Sorting = New SortingCollection(New SortProperty("TransDate", DB.SortingDirection.Ascending))
            For Each obj As PurchaseOrder In xp
                obj.Details.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
                For Each objPurchaseOrderDetail In obj.Details
                    Dim objSalesOrderDetail = NestedUnitOfWork.FindObject(Of SalesOrderDetail)(PersistentCriteriaEvaluationBehavior.InTransaction, GroupOperator.And(New BinaryOperator("SalesOrder", SalesOrder), New BinaryOperator("Item", objPurchaseOrderDetail.Item)))
                    If objSalesOrderDetail Is Nothing Then
                        objSalesOrderDetail = New SalesOrderDetail(NestedUnitOfWork)
                        objSalesOrderDetail.SalesOrder = SalesOrder
                        objSalesOrderDetail.Item = objPurchaseOrderDetail.Item
                    End If
                    objSalesOrderDetail.Quantity += objPurchaseOrderDetail.OutstandingQuantity
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