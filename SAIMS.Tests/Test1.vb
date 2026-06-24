Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SAIMS_Sales_and_Inventory_Management_System

Namespace SAIMS.Tests

    <TestClass>
    Public Class PasswordHelperTests

        <TestMethod>
        Public Sub HashPassword_ReturnsNonEmptyHash()
            Dim hash As String = PasswordHelper.HashPassword("password123")
            Assert.IsFalse(String.IsNullOrEmpty(hash))
        End Sub

        <TestMethod>
        Public Sub VerifyPassword_CorrectPassword_ReturnsTrue()
            Dim hash As String = PasswordHelper.HashPassword("mySecret!")
            Assert.IsTrue(PasswordHelper.VerifyPassword("mySecret!", hash))
        End Sub

        <TestMethod>
        Public Sub VerifyPassword_WrongPassword_ReturnsFalse()
            Dim hash As String = PasswordHelper.HashPassword("mySecret!")
            Assert.IsFalse(PasswordHelper.VerifyPassword("wrongPass", hash))
        End Sub

        <TestMethod>
        Public Sub HashPassword_SameInput_ProducesDifferentHashes()
            Dim h1 As String = PasswordHelper.HashPassword("abc")
            Dim h2 As String = PasswordHelper.HashPassword("abc")
            Assert.AreNotEqual(h1, h2, "BCrypt should use a unique salt each time.")
        End Sub

    End Class

    <TestClass>
    Public Class InputHelperTests

        <TestMethod>
        Public Sub SanitizeInput_TrimsWhitespace()
            Assert.AreEqual("hello", InputHelper.SanitizeInput("  hello  "))
        End Sub

        <TestMethod>
        Public Sub SanitizeInput_RemovesAngleBrackets()
            Assert.AreEqual("script", InputHelper.SanitizeInput("<script>"))
        End Sub

        <TestMethod>
        Public Sub SanitizeInput_NullOrWhiteSpace_ReturnsEmpty()
            Assert.AreEqual(String.Empty, InputHelper.SanitizeInput(""))
            Assert.AreEqual(String.Empty, InputHelper.SanitizeInput("   "))
        End Sub

    End Class

    <TestClass>
    Public Class ReceiptNumberTests

        <TestMethod>
        Public Sub GenerateReceiptNo_StartsWithRCP()
            Dim receiptNo As String = SalesRepository.GenerateReceiptNo()
            Assert.IsTrue(receiptNo.StartsWith("RCP-"),
                          $"Expected 'RCP-' prefix, got: {receiptNo}")
        End Sub

        <TestMethod>
        Public Sub GenerateReceiptNo_HasExpectedLength()
            Dim receiptNo As String = SalesRepository.GenerateReceiptNo()
            ' Format: RCP-yyyyMMdd-HHmmss = 19 chars
            Assert.AreEqual(19, receiptNo.Length,
                            $"Unexpected length for: {receiptNo}")
        End Sub

        <TestMethod>
        Public Sub GenerateReceiptNo_TwoCallsAreDifferent()
            Dim r1 As String = SalesRepository.GenerateReceiptNo()
            System.Threading.Thread.Sleep(1100)
            Dim r2 As String = SalesRepository.GenerateReceiptNo()
            Assert.AreNotEqual(r1, r2,
                               "Two receipt numbers generated >1s apart should differ.")
        End Sub

    End Class

End Namespace
