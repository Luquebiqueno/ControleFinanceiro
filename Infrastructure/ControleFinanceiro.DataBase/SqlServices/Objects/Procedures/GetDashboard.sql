Use ControleFinanceiro
Go

If Object_Id('GetDashboard') Is Not Null
Begin
	Drop Procedure GetDashboard
End
Go

Set Ansi_Nulls On
Go

Set Quoted_Identifier On
Go

Create Procedure GetDashboard 
(
	 @UsuarioId		Int
	,@DataInicial	Date
	,@DataFinal		Date
)
As
Begin
	Drop Table If Exists #Gastos
	Drop Table If Exists #GastosRetorno

	Create Table #GastosRetorno
	(
		 Id				Int Identity(1,1)
		,Mes			Varchar(20)
		,GastoFixo		Decimal(12,4)
		,GastoVariavel	Decimal(12,4)
	)
	
	Select 
		 DataCompra		= Format(DataCompra, 'MMM/yyyy', 'pt-BR') 
		,Valor			= Sum(Valor)
		,GastoTipoId	= GastoTipoId
	Into #Gastos
	From Gasto (Nolock)
	Where Ativo = 1
	And UsuarioCadastro = @UsuarioId
	And DataCompra Between @DataInicial And @DataFinal
	Group By Format(DataCompra, 'MMM/yyyy', 'pt-BR'), GastoTipoId
	Order By DataCompra
	
	While (@DataInicial <= @DataFinal)
	Begin
		Insert Into #GastosRetorno
		(
			Mes
		)
		Select Mes = Format(@DataInicial, 'MMM/yyyy', 'pt-BR') 

		Set @DataInicial = DateAdd(mm, 1, @DataInicial)
	End
	
	Update Gr
	Set Gr.GastoFixo = Ga.Valor
	From #GastosRetorno Gr
	Inner Join #Gastos Ga On Trim(Ga.DataCompra) = Trim(Gr.Mes)
	Where Ga.GastoTipoId = 1
	
	Update Gr
	Set Gr.GastoVariavel = Ga.Valor
	From #GastosRetorno Gr
	Inner Join #Gastos Ga On Trim(Ga.DataCompra) = Trim(Gr.Mes)
	Where Ga.GastoTipoId = 2
	
	Select
		 Mes			= Mes			
		,GastoFixo		= IsNull(GastoFixo, 0)		
		,GastoVariavel	= IsNull(GastoVariavel, 0)	
	From #GastosRetorno
	Order By Id
End	
Go
