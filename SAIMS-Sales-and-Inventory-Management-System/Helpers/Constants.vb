Public Module Constants

    ' User types
    Public Const USERTYPE_ADMIN   As String = "Admin"
    Public Const USERTYPE_CASHIER As String = "Cashier"
    Public Const USERTYPE_MANAGER As String = "Manager"
    Public Const USERTYPE_STAFF   As String = "Staff"

    ' Record statuses
    Public Const STATUS_ACTIVE   As String = "Active"
    Public Const STATUS_INACTIVE As String = "Inactive"

    ' Stock movement types
    Public Const MOVEMENT_STOCKIN  As String = "StockIn"
    Public Const MOVEMENT_STOCKOUT As String = "StockOut"
    Public Const MOVEMENT_SALE     As String = "Sale"

    ' Payment methods
    Public Const PAYMENT_CASH        As String = "Cash"
    Public Const PAYMENT_GCASH       As String = "GCash"
    Public Const PAYMENT_CREDIT_CARD As String = "Credit Card"
    Public Const PAYMENT_DEBIT_CARD  As String = "Debit Card"

    ' Sale statuses
    Public Const SALE_COMPLETED As String = "Completed"
    Public Const SALE_VOIDED    As String = "Voided"

    ' Activity log results
    Public Const LOG_SUCCESS As String = "Success"
    Public Const LOG_FAILED  As String = "Failed"
    Public Const LOG_WARNING As String = "Warning"

    ' Low stock threshold default
    Public Const DEFAULT_LOW_STOCK_QTY As Integer = 10

    ' Security questions offered for the forgot-password flow
    Public ReadOnly SecurityQuestions As String() = {
        "What was the name of your first pet?",
        "What is your mother's maiden name?",
        "What city were you born in?",
        "What was the name of your elementary school?",
        "What is your favorite book?"
    }

End Module
