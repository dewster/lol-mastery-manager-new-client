Partial Public Module ClientControls

    Public Class ClientMasteryPageNameInputField

        Public Const Width As Integer = 0
        Public Const Height As Integer = 0

        Public Structure ChampionSelect

            Public Structure Small

                Public Const X As Double = ClientSize.Small.Width / 55
                Public Const Y As Double = ClientSize.Small.Height / 125

            End Structure

            Public Structure Medium

                Public Const X As Double = ClientSize.Medium.Width / 55
                Public Const Y As Double = ClientSize.Medium.Height / 125

            End Structure

            Public Structure Large

                Public Const X As Double = ClientSize.Large.Width / 55
                Public Const Y As Double = ClientSize.Medium.Height / 125

            End Structure

        End Structure

        Public Structure Menu

            Public Const X As Double = ClientSize.Small.Width / 50
            Public Const Y As Double = ClientSize.Small.Height / 160

        End Structure

    End Class

End Module
