Use ControleFinanceiro
Go

If Object_Id('GetBarChart') Is Not Null
Begin
	Drop Procedure GetBarChart
End
Go

SET ANSI_NULLS ON
Go

SET QUOTED_IDENTIFIER ON
Go

Create Procedure GetBarChart (
 @UsuarioId		Int
,@DataInicial	Date
,@DataFinal		Date
)
As
Begin
Set Language 'Brazilian'
	Select 
		 ValorMensal	= Sum(Valor)
		,Mes			= DateName(mm, DataCompra)
		,MesCompra		= DatePart(mm, DataCompra)
	From Gasto (Nolock)
	Where UsuarioCadastro = @UsuarioId
	And DataCompra Between @DataInicial And @DataFinal
	And Ativo = 1
	Group By 
	 DATENAME(mm, DataCompra)
	,DatePart(mm, DataCompra)
	Order By 
	DatePart(mm, DataCompra)
End	
Go
