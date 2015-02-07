Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Public Class frmWIzardPurchaseInvoiceFromPurchaseOrder
    Public Sub New(ByVal prmObjectSpace As XPObjectSpace, ByVal prmPurchaseInvoice As PurchaseInvoice)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _nestedUnitOfWork = prmObjectSpace.Session.BeginNestedUnitOfWork
        _purchaseInvoice = NestedUnitOfWork.GetNestedObject(prmPurchaseInvoice)

        Dim xp As New XPCollection(Of PurchaseOrder)(NestedUnitOfWork, GroupOperator.And(New BinaryOperator("Supplier", PurchaseInvoice.Supplier), _
                                                                                         New BinaryOperator("TransDate", PurchaseInvoice.TransDate, BinaryOperatorType.LessOrEqual), _
                                                                                         New BinaryOperator("Status", TransactionStatus.Submitted), _
                                                                                         New BinaryOperator("InvoicingOutstandingStatus", OutstandingStatus.Clear, BinaryOperatorType.NotEqual)))
        Dim xpDataSource As New XPCollection(Of PurchaseOrder)(NestedUnitOfWork, False)
        For Each obj In xp
            xpDataSource.Add(obj)
        Next
        cgrDataPurchaseOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "No", .FieldName = "No", .Visible = True, .VisibleIndex = 1})
        cgrDataPurchaseOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "ReferenceNo", .FieldName = "ReferenceNo", .Visible = True, .VisibleIndex = 2})
        cgrDataPurchaseOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "TransDate", .FieldName = "TransDate", .Visible = True, .VisibleIndex = 3})
        cgrDataPurchaseOrder.DataSource = xpDataSource
    End Sub
    Private _nestedUnitOfWork As NestedUnitOfWork
    Private _purchaseInvoice As PurchaseInvoice

    Public ReadOnly Property NestedUnitOfWork As NestedUnitOfWork
        Get
            Return _nestedUnitOfWork
        End Get
    End Property
    Public ReadOnly Property PurchaseInvoice As PurchaseInvoice
        Get
            Return _purchaseInvoice
        End Get
    End Property

    Private Sub btnWizard_Click(sender As Object, e As EventArgs) Handles btnWizard.Click
        Try
            Dim xp As New XPCollection(Of PurchaseOrder)(NestedUnitOfWork, False)
            For Each obj In cgrDataPurchaseOrder.SelectedObjects
                xp.Add(obj)
            Next
            xp.Sorting = New SortingCollection(New SortProperty("TransDate", DB.SortingDirection.Ascending))
            For Each Obj As PurchaseOrder In xp
                Obj.Details.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
                For Each objPurchaseOrderDetail In Obj.Details
                    Dim objPurchaseInvoiceDetail As New PurchaseInvoiceDetail(NestedUnitOfWork)
                    objPurchaseInvoiceDetail.PurchaseInvoice = PurchaseInvoice
                    objPurchaseInvoiceDetail.PurchaseOrderDetail = objPurchaseOrderDetail
                    'objPurchaseInvoiceDetail.PricePerUnit = objPurchaseOrderDetail.PurchaseOrder.Currency.ConvertToCurrencyRate(PurchaseInvoice.Currency, PurchaseInvoice.TransDate) * objPurchaseOrderDetail.PricePerUnit
                    'objPurchaseInvoiceDetail.Quantity = objPurchaseOrderDetail.OutstandingQuantity
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