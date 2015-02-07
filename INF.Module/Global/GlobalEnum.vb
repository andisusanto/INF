Imports DevExpress.Persistent.Base

Public Module GlobalEnum
    Public Enum TransactionStatus
        Entry
        Submitted
    End Enum

    Public Enum ParameterType
        SpecificDate
        DateRange
        [Object]
        [Enum]
    End Enum

    Public Enum OutstandingStatus
        <ImageName("Full")>
        Full
        <ImageName("Partial")>
        [Partial]
        <ImageName("Cleared")>
        Clear
    End Enum

    Public Enum RoundingType
        None
        Normal
        Up
        Down
    End Enum
End Module
