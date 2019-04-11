rm *.nupkg
nuget pack Analytics.Xamarin.nuspec -IncludeReferencedProjects -Prop Configuration=Release
# nuget push -source https://www.nuget.org -NonInteractive *.nupkg