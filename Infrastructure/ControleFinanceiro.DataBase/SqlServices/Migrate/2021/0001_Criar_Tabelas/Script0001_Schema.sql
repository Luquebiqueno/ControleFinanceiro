Use ControleFinanceiro
Go

If Object_Id('Usuario') Is Null 
Begin
	Create Table Usuario 
	(
		 UsuarioId			Int Identity(1,1) Primary Key
		,Nome				Varchar(128)	Not Null
		,Email				Varchar(100)	Not Null
		,Telefone			BigInt				Null
		,Login				Varchar(128)	Not Null
		,Senha				Varchar(400)	Not Null
		,DataCadastro		Datetime		Not	Null
		,DataAlteracao		DateTime			Null
		,UsuarioAlteracao	Int					Null
	)
End
Go

If Object_Id('GastoTipo') Is Null 
Begin
	Create Table GastoTipo 
	(
		 GastoTipoId	Int Identity(1,1) Constraint PK_GastoTipo_GastoTipoId Primary Key
		,Descricao		Varchar(50) Not Null
	)
End
Go


If Object_Id('Gasto') Is Null 
Begin
	Create Table Gasto 
	(
		 GastoId			Int Identity(1,1) Constraint PK_Gasto_GastoTipoId Primary Key
		,Item				Varchar(200)	Not Null
		,Valor				Decimal(12,4)	Not Null
		,DataCompra			Date			Not Null
		,DataCadastro		Datetime		Not Null
		,UsuarioCadastro	Int				Not Null	References Usuario (UsuarioId)
		,DataAlteracao		DateTime			Null
		,UsuarioAlteracao	Int					Null
		,GastoTipoId		Int				Not Null	References GastoTipo (GastoTipoId)	
	)
End
Go

