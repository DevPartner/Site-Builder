DECLARE @entityTypeIdGallery INT

SELECT @entityTypeIdGallery = [Id]
  FROM [dbo].[DP_EntityType]
  WHERE [Name]='Gallery'

print 'EntityTypeId for Gallery:' + CAST(@entityTypeIdGallery AS NVARCHAR(MAX))


DECLARE @entityTypeIdFolder INT

SELECT @entityTypeIdFolder = [Id]
  FROM [dbo].[DP_EntityType]
  WHERE [Name]='Folder'

print 'EntityTypeId for Folder:' + CAST(@entityTypeIdFolder AS NVARCHAR(MAX))


DECLARE @parentIdFolder INT

SELECT @parentIdFolder=[Id]
  FROM [dbo].[DP_Entity]
  where [Name]='Gallery' AND [EntityTypeId]=@entityTypeIdFolder

print 'ParentId for for Galleries:' + CAST(@parentIdFolder AS NVARCHAR(MAX))

INSERT INTO [dbo].[DP_Entity]
           ([EntityTypeId]
           ,[Name]
           ,[ParentId]
           ,[Description]
           ,[ExtId]
           ,[DisplayOrder])
SELECT @entityTypeIdGallery
      ,[Name]
	  ,@parentIdFolder
      ,[Description]
      --,[PictureId]
	  ,[Id] -- ExtId
      ,[DisplayOrder]
	  --,[Type]
  FROM [dbo].[Gallery]

DECLARE @attThumbnailImage INT

SELECT @attThumbnailImage=att.[Id]
  FROM [dbo].[DP_Scheme] s
	INNER JOIN [DP_AttType] att ON s.AttTypeId=att.Id 
  WHERE [EntityTypeId]=@entityTypeIdGallery and att.[Name]='ThumbnailImage'
  
print 'AttId for for ThumbnailImage:' + CAST(@attThumbnailImage AS NVARCHAR(MAX))

INSERT INTO [dbo].[DP_AttPicture]
           ([EntityId]
           ,[AttTypeId]
           ,[PictureId]
           ,[TableId])
SELECT e.Id
	  ,@attThumbnailImage
      ,g.[PictureId]
	  ,null
  FROM [dbo].[Gallery] g
  INNER JOIN [dbo].[DP_Entity] e on g.Id=e.ExtId and e.EntityTypeId=@entityTypeIdGallery



DECLARE @attGalleryPageTemplate INT

SELECT @attGalleryPageTemplate=att.Id
  FROM [dbo].[DP_Scheme] s
	INNER JOIN [DP_AttType] att ON s.AttTypeId=att.Id 
  WHERE [EntityTypeId]=@entityTypeIdGallery AND [Name]='GalleryPageTemplate'

print 'AttId for for GalleryPageTemplate:' + CAST(@attGalleryPageTemplate AS NVARCHAR(MAX))

DECLARE @entityTypeIdGalleryPageTemplate INT

SELECT @entityTypeIdGalleryPageTemplate = [Id]
  FROM [dbo].[DP_EntityType]
  WHERE [Name]='GalleryPageTemplate'

print 'EntityTypeId for GalleryPageTemplate:' + CAST(@entityTypeIdGalleryPageTemplate AS NVARCHAR(MAX))


DECLARE @entityIdGalleryVideoPage INT

SELECT @entityIdGalleryVideoPage = [Id]
  FROM [dbo].[DP_Entity]
  WHERE [EntityTypeId]=@entityTypeIdGalleryPageTemplate AND [Name]='GalleryVideoPage'

print 'EntityId for GalleryVideoPage:' + CAST(@entityIdGalleryVideoPage AS NVARCHAR(MAX))

INSERT INTO [dbo].[DP_AttExtRef]
           ([EntityId]
           ,[AttTypeId]
           ,[AttExtRefId]
           ,[TableId])
SELECT e.Id
	  ,@attGalleryPageTemplate
      ,@entityIdGalleryVideoPage
	  ,null
  FROM [dbo].[Gallery] g
  INNER JOIN [dbo].[DP_Entity] e on g.Id=e.ExtId and e.EntityTypeId=@entityTypeIdGallery AND g.[Type]='VideoGallery'


DECLARE @entityIdGalleryGridPage INT

SELECT @entityIdGalleryGridPage = [Id]
  FROM [dbo].[DP_Entity]
  WHERE [EntityTypeId]=@entityTypeIdGalleryPageTemplate AND [Name]='GalleryGridPage'

print 'EntityId for GalleryGridPage:' + CAST(@entityIdGalleryGridPage AS NVARCHAR(MAX))


INSERT INTO [dbo].[DP_AttExtRef]
           ([EntityId]
           ,[AttTypeId]
           ,[AttExtRefId]
           ,[TableId])
SELECT e.Id
	  ,@attGalleryPageTemplate
      ,@entityIdGalleryGridPage
	  ,null
  FROM [dbo].[Gallery] g
  INNER JOIN [dbo].[DP_Entity] e on g.Id=e.ExtId and e.EntityTypeId=@entityTypeIdGallery AND g.[Type]='SimpleGallery'

exec [DP_UpdateXml] @entityTypeIdGallery, null

-- update localization Gallery
UPDATE lp
SET EntityId = e.Id, LocaleKeyGroup='Entity'
FROM [dbo].[LocalizedProperty] lp
  INNER JOIN  [dbo].[Gallery] g  on g.Id=lp.EntityId and lp.[LocaleKeyGroup]='Gallery'
  INNER JOIN [dbo].[DP_Entity] e on g.Id=e.ExtId and e.EntityTypeId=@entityTypeIdGallery 


  
DECLARE @entityTypeIdImageVideo INT

SELECT @entityTypeIdImageVideo = [Id]
  FROM [dbo].[DP_EntityType]
  WHERE [Name]='ImageVideo'

print 'EntityTypeId for ImageVideo:' + CAST(@entityTypeIdImageVideo AS NVARCHAR(MAX))

INSERT INTO [dbo].[DP_Entity]
           ([EntityTypeId]
           ,[Name]
           --,[ParentId]
           ,[Description]
           ,[ExtId]
           ,[DisplayOrder])
SELECT @entityTypeIdImageVideo
      ,[Name]
      ,[Description]
	  ,[Id]
      ,[DisplayOrder]
  FROM [dbo].[ImageGallery]

INSERT INTO [dbo].[DP_AttPicture]
           ([EntityId]
           ,[AttTypeId]
           ,[PictureId]
           ,[TableId])
SELECT e.Id
	  ,@attThumbnailImage
      ,ig.[PictureId]
	  ,null
  FROM [dbo].[ImageGallery] ig
  INNER JOIN [dbo].[DP_Entity] e on ig.Id=e.ExtId and e.EntityTypeId=@entityTypeIdImageVideo

-- update localization GalleryImages
UPDATE lp
SET EntityId = e.Id, LocaleKeyGroup='Entity'
FROM [dbo].[LocalizedProperty] lp
  INNER JOIN  [dbo].[ImageGallery] ig  on ig.Id=lp.EntityId and lp.[LocaleKeyGroup]='GalleryImages'
  INNER JOIN [dbo].[DP_Entity] e on ig.Id=e.ExtId and e.EntityTypeId=@entityTypeIdImageVideo 

--set parentId
UPDATE e
SET ParentId = eParent.Id
FROM [dbo].[DP_Entity] e 
	INNER JOIN [dbo].[Galleries_GalleryImagesMapping] gim ON e.ExtId = gim.GalleryImages_Id
	INNER JOIN [dbo].[DP_Entity] eParent ON eParent.ExtId = gim.Galleries_Id AND eParent.EntityTypeId=@entityTypeIdGallery
WHERE e.[EntityTypeId] = @entityTypeIdImageVideo


exec [DP_UpdateXml] @entityTypeIdImageVideo, null