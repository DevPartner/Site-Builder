declare @refTypeImageVideoTypeId int 

INSERT INTO [dbo].[DP_AttRefType]
           ([Name])
     VALUES
           ('ImageVideoType')

set @refTypeImageVideoTypeId = @@IDENTITY

INSERT INTO [dbo].[DP_AttRefBook]
           ([RefAttTypeId]
           ,[Value])
     VALUES
           (@refTypeImageVideoTypeId
           ,'Image')

INSERT INTO [dbo].[DP_AttRefBook]
           ([RefAttTypeId]
           ,[Value])
     VALUES
           (@refTypeImageVideoTypeId
           ,'Video')