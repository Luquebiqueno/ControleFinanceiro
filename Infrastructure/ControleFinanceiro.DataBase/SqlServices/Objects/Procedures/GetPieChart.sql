Use ControleFinanceiro
Go

If Object_Id('GetPieChart') Is Not Null
Begin
	Drop Procedure GetPieChart
End
Go

SET ANSI_NULLS ON
Go

SET QUOTED_IDENTIFIER ON
Go

Create Procedure GetPieChart (
 @UsuarioId		Int
,@DataInicial	Date
,@DataFinal		Date
)
As
Begin
	Select 
		 ValorMensal	= Sum(Valor)
		,GastoTipo		= Gt.Descricao
	From Gasto Ga (Nolock)
	Join GastoTipo Gt (Nolock) On Ga.GastoTipoId = Gt.GastoTipoId
	Where UsuarioCadastro = @UsuarioId
	And (DatePart(mm,DataCompra) Between DatePart(mm, @DataInicial) And DatePart(mm, @DataFinal))
	And Ga.Ativo = 1
	Group By 
	 Gt.Descricao
End	
Go
