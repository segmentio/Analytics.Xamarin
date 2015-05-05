MDTOOL ?= /Applications/Xamarin\ Studio.app/Contents/MacOS/mdtool
COMPONENT ?= bin/xamarin-component.exe

build:
	$(MDTOOL) build -c:Release ./Analytics.Xamarin.sln

clean:
	$(MDTOOL) build -t:Clean ./ReactiveUI_XSAll.sln

package:
	@mono $(COMPONENT) package component
