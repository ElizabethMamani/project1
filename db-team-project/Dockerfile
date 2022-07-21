FROM mcr.microsoft.com/mssql/server:2019-latest

COPY ./entrypoint.sh .
COPY ./StudentManagerDB.sql .

ENTRYPOINT [ "/bin/bash", "entrypoint.sh" ]

CMD [ "/opt/mssql/bin/sqlservr"]