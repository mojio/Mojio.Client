@set NUGET=Build\NuGet

@echo =========================
@echo NuGet package publishing.

setlocal enabledelayedexpansion
@for %%g in (Build\Mojio.Client.*.nupkg) do (
  @echo Publishing %%g
  @%NUGET% Push %%g 
  @if not errorlevel 0 goto error
)
endlocal

@echo Mojio.Client publishing sucessful.
@goto end

:error
@echo Error occured during Mojio.Client publishing.
@goto end

:end
@pause