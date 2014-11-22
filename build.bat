@set NUGET=Build\NuGet
@set SRC_DIR=Src\Mojio.Client
@set CSPROJ=%SRC_DIR%\Mojio.Client.csproj


@echo =====================
@echo Building Mojio.Client

@%NUGET% pack %CSPROJ% -IncludeReferencedProjects -Prop Configuration=Release -o Build
@if not errorlevel 0 goto error

@echo Mojio.Client build successful.
@goto end

:error
@echo Error occured during Mojio.Client build.
@goto end

:end
@pause