SELECT
  Ng.Id as "@NgId",
	LEFT(Ng.Fra_Min, 4) as "NgFra",
	LEFT(Ng.Til_Max, 4) as "NgTil",
	( SELECT
	    NgNavnArtId as "@NgNavnArtId",
	    ISNULL(Ng.PrefixNavn + ', ', '') + NgNavn.Navn as "*"
	  FROM NgNavn
	  WHERE NgNavn.NgId = Ng.Id
	  ORDER BY
		  (case when NgNavnArtId >= 10 then 0 else 1 end), -- 1) Navne med art altid før uoplyst etc.,
		  (case when Til_Max IS NULL then 0 else 1 end),   -- 2) gældende navne før afsluttede,
		  NgNavnArtId,                                     -- 3) prioriteret efter artId,
		  Til_Max desc,                                    -- 4) (afslut. navne:) senest afsl. først
		  ISNULL(Fra_Min, '99999999') asc,                 -- 5) længst gældende først
		  navn                                             -- 6) ellers: navn alfabetisk
	  FOR XML PATH ('NgNavn'), TYPE
	),
	BemPublikum as "NgNote",
	( SELECT
	    He.Id as "@HeId",
	    LEFT(LedFra_min, 4) AS "HeFra",
      LEFT(LedTil_max, 4) AS "HeTil",
	    ( SELECT HeNavnArtId as "@HeNavnArtId", Navn as "*"
        FROM HeNavn
        WHERE HeNavn.HeId = He.Id
          and Navn not like '%intet navn%'
        order by (case when HeNavnArtId > 10 then HeNavnArtId else (HeNavnArtId + 1000) end), Id
        FOR XML PATH('HeNavn'), TYPE
      ),
      NULLIF(cast(PubBem as varchar(4000)), '') as "HeNote"
    FROM He join Ng2He on He.Id = Ng2He.HeId
    WHERE Ng2He.NgId = Ng.Id
      and He.Kladde = 0
    FOR XML PATH ('He'), TYPE
  )
FROM Ng
WHERE KortNavn like 'Justitsmini%' 
FOR XML PATH('Ng'), ROOT('APEx')

