Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Public Class frmWizardSalesInvoiceFromSalesOrders
    Public Sub New(ByVal prmObjectSpace As XPObjectSpace, ByVal prmSalesInvoice As SalesInvoice)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _nestedUnitOfWork = prmObjectSpace.Session.BeginNestedUnitOfWork()
        _salesInvoice = NestedUnitOfWork.GetNestedObject(prmSalesInvoice)

        Dim xp As New XPCollection(Of SalesOrder)(NestedUnitOfWork, GroupOperator.And(New BinaryOperator("Customer", SalesInvoice.Customer), _
                                                                                         New BinaryOperator("TransDate", SalesInvoice.TransDate, BinaryOperatorType.LessOrEqual), _
                                                                                         New BinaryOperator("Status", TransactionStatus.Submitted), _
                                                                                         New BinaryOperator("InvoicingOutstandingStatus", OutstandingStatus.Clear, BinaryOperatorType.NotEqual)))
        Dim xpDataSource As New XPCollection(Of SalesOrder)(NestedUnitOfWork, False)
        For Each obj In xp
            xpDataSource.Add(obj)
        Next
        cgrDataSalesOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "No", .FieldName = "No", .Visible = True, .VisibleIndex = 1})
        cgrDataSalesOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "ReferenceNo", .FieldName = "ReferenceNo", .Visible = True, .VisibleIndex = 2})
        cgrDataSalesOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "TransDate", .FieldName = "TransDate", .Visible = True, .VisibleIndex = 3})
        cgrDataSalesOrder.DataSource = xpDataSource
    End Sub
    Private _nestedUnitOfWork As NestedUnitOfWork
    Private _salesInvoice As SalesInvoice
    Public ReadOnly Property NestedUnitOfWork As NestedUnitOfWork
        Get
            Return _nestedUnitOfWork
        End Get
    End Property
    Public ReadOnly Property SalesInvoice As SalesInvoice
        Get
            Return _salesInvoice
        End Get
    End Property

    Private Sub btnWizard_Click(sender As Object, e As EventArgs) Handles btnWizard.Click
        Try
            Dim xp As New XPCollection(Of SalesOrder)(NestedUnitOfWork, False)
            For Each obj In cgrDataSalesOrder.SelectedObjects
                xp.Add(obj)
            Next
            xp.Sorting = New SortingCollection(New SortProperty("TransDate", DB.SortingDirection.Ascending))
            For Each obj As SalesOrder In xp
                obj.Details.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
                For Each objSalesOrderDetail In obj.Details
                    Dim objSalesInvoiceDetail As New SalesInvoiceDetail(NestedUnitOfWork)
                    objSalesInvoiceDetail.SalesInvoice = SalesInvoice
                    objSalesInvoiceDetail.SalesOrderDetail = objSalesOrderDetail
                    'objSalesInvoiceDetail.PricePerUnit = objSalesOrderDetail.SalesOrder.Currency.ConvertToCurrencyRate(SalesInvoice.Currency, SalesInvoice.TransDate) * objSalesOrderDetail.PricePerUnit
                    'objSalesInvoiceDetail.Quantity = objSalesOrderDetail.OutstandingQuantity
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