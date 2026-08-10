Public Class CategoryDialogForm

    Public Property IsEditMode As Boolean = False
    Public Property CategoryID As Integer = 0
    Public Property CategoryNameInput As String = ""
    Public Property DescriptionInput As String = ""
    Public Property StatusInput As String = Constants.STATUS_ACTIVE

    Private Sub CategoryDialogForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboStatus.SelectedIndex = 0

        If IsEditMode Then
            lblHeaderTitle.Text = "Edit Category"
            Me.Text = "Edit Category"
            txtCategoryName.Text = CategoryNameInput
            txtDescription.Text = DescriptionInput
            If Not String.IsNullOrEmpty(StatusInput) AndAlso cboStatus.Items.Contains(StatusInput) Then
                cboStatus.SelectedItem = StatusInput
            End If
        Else
            lblHeaderTitle.Text = "Add New Category"
            Me.Text = "Add New Category"
            txtCategoryName.Text = ""
            txtDescription.Text = ""
            cboStatus.SelectedItem = Constants.STATUS_ACTIVE
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim name As String = InputHelper.SanitizeInput(txtCategoryName.Text.Trim())
        Dim desc As String = InputHelper.SanitizeInput(txtDescription.Text.Trim())
        Dim status As String = If(cboStatus.SelectedItem IsNot Nothing, cboStatus.SelectedItem.ToString(), Constants.STATUS_ACTIVE)

        If String.IsNullOrWhiteSpace(name) Then
            MessageBox.Show("Category Name is required.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryName.Focus()
            Return
        End If

        CategoryNameInput = name
        DescriptionInput = desc
        StatusInput = status

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
