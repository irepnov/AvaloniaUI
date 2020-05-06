INSERT INTO "public"."Companys"("Name", "INN") VALUES ('Comp 1', '11111');
INSERT INTO "public"."Companys"("Name", "INN") VALUES ('Company 2', '222');
INSERT INTO "public"."Companys"("Name", "INN") VALUES ('Comp 3', '3');

insert into "public"."Phones"("Title", "CompanyId") Values ('phone 1', 1);
insert into "public"."Phones"("Title", "CompanyId") Values ('phone 2', 1);
insert into "public"."Phones"("Title", "CompanyId") Values ('phone 11', 1);
insert into "public"."Phones"("Title", "CompanyId") Values ('phone 22', 2);
insert into "public"."Phones"("Title", "CompanyId") Values ('phone 2222', 2);
insert into "public"."Phones"("Title", "CompanyId") Values ('phone 3', 3);
insert into "public"."Phones"("Title", "CompanyId") Values ('phone 33', 3);
insert into "public"."Phones"("Title", "CompanyId") Values ('phone 333', 3);
insert into "public"."Phones"("Title", "CompanyId") Values ('phone 3333', 3);

select * from "public"."Companys";
select * from "public"."Phones" order by "CompanyId" LIMIT 5;