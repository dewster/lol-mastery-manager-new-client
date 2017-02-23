Partial Public Module ClientControls

    Public Class ClientReturnPointsButton

        Public Const Width As Integer = 0
        Public Const Height As Integer = 0

        Public Structure ChampionSelect

            Public Structure Small

                Public Const X As Double = ClientSize.Small.Width / 1100
                Public Const Y As Double = ClientSize.Small.Height / 125

            End Structure

            Public Structure Medium

                Public Const X As Double = ClientSize.Medium.Width / 1100
                Public Const Y As Double = ClientSize.Medium.Height / 125

            End Structure

            Public Structure Large

                Public Const X As Double = ClientSize.Large.Width / 1100
                Public Const Y As Double = ClientSize.Large.Height / 125

            End Structure

        End Structure

        Public Structure Menu

            Public Const X As Double = ClientSize.Small.Width / 883
            Public Const Y As Double = ClientSize.Small.Height / 160

        End Structure

    End Class

End Module
