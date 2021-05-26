using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			/*
            var sp = @"CREATE PROCEDURE [DeleteRecordFromTable]
	                    @P_tableName nvarchar(50) = null,
	                    @P_Id nvarchar = null
                    AS
                    BEGIN
	                    SET NOCOUNT ON;
	
	                    declare @V_table nvarchar(50) = null
	                    if (@P_tableName is not null)
		                    select @V_table = QUOTENAME( TABLE_NAME )
		                    FROM INFORMATION_SCHEMA.TABLES
		                    WHERE TABLE_NAME = @P_tableName

	                    declare @V_sql as nvarchar(MAX) = null
	                    if (@V_table is not null and @P_Id is not null)
		                    SELECT @V_sql = 'DELETE FROM ' + @V_table + 'WHERE ID = ' + @P_Id + ';'

	                    if(@V_sql is not null)
		                    EXEC(@V_sql)
	                    else
		                    select 0;
                    END";
            migrationBuilder.Sql(sp);

            sp = @"CREATE PROCEDURE [GetAllRecordsFromTable]
	                @P_tableName nvarchar(50) = null
                AS
                BEGIN
	                SET NOCOUNT ON;
	
	                declare @V_table nvarchar(50) = null
	                if (@P_tableName is not null)
		                select @V_table = QUOTENAME( TABLE_NAME )
		                FROM INFORMATION_SCHEMA.TABLES
		                WHERE TABLE_NAME = @P_tableName

	                declare @V_sql as nvarchar(MAX) = null
	                if (@V_table is not null)
		                select @V_sql = 'select * from ' + @V_table + ';'

	                if(@V_sql is not null)
		                exec(@V_sql)
	                else
	                ";
            migrationBuilder.Sql(sp);

            sp = @"CREATE PROCEDURE [GetRecordByIdFromTable]
					@P_tableName nvarchar(50) = null,
					@P_Id nvarchar = null
				AS
				BEGIN
					SET NOCOUNT ON;
	
					declare @V_table nvarchar(50) = null
					if (@P_tableName is not null)
						select @V_table = QUOTENAME( TABLE_NAME )
						FROM INFORMATION_SCHEMA.TABLES
						WHERE TABLE_NAME = @P_tableName

					declare @V_sql as nvarchar(MAX) = null
					if (@V_table is not null and @P_Id is not null)
						select @V_sql = 'select * from ' + @V_table + ' where Id = ' + @P_Id + ';'

					if(@V_sql is not null)
						exec(@V_sql)
					else
						select -1;
				END";
            migrationBuilder.Sql(sp);

            sp = @"CREATE PROCEDURE [InsertRecordToTable]
					@P_tableName nvarchar(50) = null,
					@P_columnsString nvarchar(MAX) = null, 
					@P_propertiesString nvarchar(MAX) = null
				AS
				BEGIN
					SET NOCOUNT ON;
	
					declare @V_table nvarchar(50) = null
					if (@P_tableName is not null)
						select @V_table = QUOTENAME( TABLE_NAME )
						FROM INFORMATION_SCHEMA.TABLES
						WHERE TABLE_NAME = @P_tableName

					declare @V_sql as nvarchar(MAX) = null
					if (@V_table is not null and @P_columnsString is not null and @P_propertiesString is not null)
						SET @V_sql = 'INSERT INTO ' + @V_table + ' (' + @P_columnsString + ') VALUES (' + @P_propertiesString + ');'
	
					if(@V_sql is not null)
						SELECT @V_sql;
					else
						SELECT -1;
				END";
            migrationBuilder.Sql(sp);

            sp = @"CREATE PROCEDURE [UpdateRecordInTable]
					@P_tableName nvarchar(50) = null,
					@P_columnsString nvarchar(MAX) = null,
					@P_Id nvarchar = null
				AS
				BEGIN
					SET NOCOUNT ON;
	
					declare @V_table nvarchar(50) = null
					if (@P_tableName is not null)
						select @V_table = QUOTENAME( TABLE_NAME )
						FROM INFORMATION_SCHEMA.TABLES
						WHERE TABLE_NAME = @P_tableName

					declare @V_sql as nvarchar(MAX) = null
					if (@V_table is not null and @P_columnsString is not null and @P_Id is not null)
						SET @V_sql = 'UPDATE ' + @V_table + ' SET ' + @P_columnsString + ' WHERE Id = ' + @P_Id + ';'

					if(@V_sql is not null)
						SELECT(@V_sql)
					else
						SELECT -1;
				END";
            migrationBuilder.Sql(sp);
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
