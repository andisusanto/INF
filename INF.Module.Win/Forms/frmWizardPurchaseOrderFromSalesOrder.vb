Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Public Class frmWizardPurchaseOrderFromSalesOrder
    Public Sub New(ByVal prmObjectSpace As XPObjectSpace, ByVal prmPurchaseOrder As PurchaseOrder)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _nestedUnitOfWork = prmObjectSpace.Session.BeginNestedUnitOfWork()
        _purchaseOrder = NestedUnitOfWork.GetNestedObject(prmPurchaseOrder)

        Dim xp As New XPCollection(Of SalesOrder)(NestedUnitOfWork, GroupOperator.And(New BinaryOperator("TransDate", PurchaseOrder.TransDate, BinaryOperatorType.LessOrEqual), _
                                                                                      New BinaryOperator("Status", TransactionStatus.Submitted), _
                                                                                      New BinaryOperator("InvoicingOutstandingStatus", OutstandingStatus.Clear, BinaryOperatorType.NotEqual)))
        Dim xpDataSource As New XPCollection(Of SalesOrder)(NestedUnitOfWork, False)
        For Each obj In xp
            xpDataSource.Add(obj)
        Next
        cgrDataSalesOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "No", .FieldName = "No", .Visible = True, .VisibleIndex = 1})
        cgrDataSalesOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "Customer", .FieldName = "Customer.Name", .Visible = True, .VisibleIndex = 2})
        cgrDataSalesOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "ReferenceNo", .FieldName = "ReferenceNo", .Visible = True, .VisibleIndex = 3})
        cgrDataSalesOrder.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "TransDate", .FieldName = "TransDate", .Visible = True, .VisibleIndex = 4})
        cgrDataSalesOrder.DataSource = xpDataSource
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
            Dim xp As New XPCollection(Of SalesOrder)(NestedUnitOfWork, False)
            For Each obj In cgrDataSalesOrder.SelectedObjects
                xp.Add(obj)
            Next
            xp.Sorting = New SortingCollection(New SortProperty("TransDate", DB.SortingDirection.Ascending))
            For Each obj As SalesOrder In xp
                obj.Details.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
                For Each objSalesOrderDetail In obj.Details
                    Dim objPuchaseOrderDetail = NestedUnitOfWork.FindObject(Of PurchaseOrderDetail)(PersistentCriteriaEvaluationBehavior.InTransaction, GroupOperator.And(New BinaryOperator("PurchaseOrder", PurchaseOrder), New BinaryOperator("Item", objSalesOrderDetail.Item)))
                    If objPuchaseOrderDetail Is Nothing Then
                        objPuchaseOrderDetail = New PurchaseOrderDetail(NestedUnitOfWork)
                        objPuchaseOrderDetail.PurchaseOrder = PurchaseOrder
                        objPuchaseOrderDetail.Item = objSalesOrderDetail.Item
                    End If
                    objPuchaseOrderDetail.Quantity += objSalesOrderDetail.OutstandingQuantity
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