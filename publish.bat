@set NUGET=Build\NuGet

@echo =========================
@echo NuGet package publishing.

@for %%g in (Build\Mojio.Client.*.nupkg) do @(
  @echo Publishing %%g
  @%NUGET% Push %%g
)

@echo Mojio.Client publishing completed.
@goto end

:end
@pause