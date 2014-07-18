MDTOOL ?= /Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool

build:
	$(MDTOOL) build -c:Release ./Analytics.Xamarin.sln

clean:
	$(MDTOOL) build -t:Clean ./ReactiveUI_XSAll.sln