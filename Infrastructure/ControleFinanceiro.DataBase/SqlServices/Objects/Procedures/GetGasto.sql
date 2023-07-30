Use ControleFinanceiro
Go

If Object_Id('GetGasto') Is Not Null
Begin
	Drop Procedure GetGasto
End
Go

SET ANSI_NULLS ON
Go

SET QUOTED_IDENTIFIER ON
Go

Create Procedure GetGasto (
 @UsuarioId		Int
,@Item			Varchar(200)	Null
,@Valor			Decimal(12,4)	Null
,@DataCompra	Date			Null
,@GastoTipoId	Int				Null	
)
As
Begin
	Select
		 Id			= Ga.GastoId
		,Item		= Ga.Item
		,Valor		= Ga.Valor
		,DataCompra	= Ga.DataCompra
		,GastoTipo	= Gt.Descricao
	From Gasto		Ga (Nolock)
	Join GastoTipo	Gt (Nolock) On Ga.GastoTipoId = Gt.GastoTipoId
	Where (Ga.UsuarioCadastro = @UsuarioId)
	And	  (Ga.Item Like '%' + @Item + '%' Or @Item Is Null Or @Item = '')
	And	  (Ga.Valor = @Valor Or @Valor Is Null Or @Valor = 0) 
	And	  (Ga.DataCompra Between @DataCompra And DateAdd(Day, 1, @DataCompra) Or @DataCompra Is Null)
	And	  (Ga.GastoTipoId = @GastoTipoId Or @GastoTipoId Is Null Or @GastoTipoId = 0)
	And	  (Ga.Ativo = 1)
End	
Go
