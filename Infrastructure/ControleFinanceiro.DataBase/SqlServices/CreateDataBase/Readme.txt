**Deixar nesta pasta apenas um script, com o comando de criação da base de dados**

Ex:

Use [master]
Go

/* 
	$RECREATE_DATABASE$ e $DATABASE_NAME$ são substituido em tempo de execucao pelo DbUp
*/
If Exists(Select * From sys.databases Where Name = '$DATABASE_NAME$' AND $RECREATE_DATABASE$ = 1)
	Begin
		ALTER DATABASE [$DATABASE_NAME$] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
		DROP DATABASE [$DATABASE_NAME$];
	End
Go

Create Database [$DATABASE_NAME$] COLLATE Latin1_General_CI_AS
Go

ALTER DATABASE [$DATABASE_NAME$] SET ENABLE_BROKER;
Go

Use [$DATABASE_NAME$]
Go
