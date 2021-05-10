Use ControleFinanceiro
Go

If Not Exists (Select Top 1 1 From GastoTipo (Nolock)) 
Begin
	Insert Into GastoTipo
	(
		Descricao
	)
	Values
	 ('Gasto Fixo')
	,('Gasto Variável')
End
Go
