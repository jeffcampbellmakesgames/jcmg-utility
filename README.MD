[![Continous Deployment](https://github.com/jeffcampbellmakesgames/jcmg-utility/actions/workflows/publish_release.yml/badge.svg)](https://github.com/jeffcampbellmakesgames/jcmg-utility/actions/workflows/publish_release.yml)
[![openupm](https://img.shields.io/npm/v/com.jeffcampbellmakesgames.utility?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.jeffcampbellmakesgames.utility/)
![GitHub issues](https://img.shields.io/github/issues/jeffcampbellmakesgames/jcmg-utility)
[![Twitter Follow](https://img.shields.io/badge/twitter-%40stampyturtle-blue.svg?style=flat&label=Follow)](https://twitter.com/stampyturtle)

# JCMG Utility
## About
JCMG Utility is a general-purpose, utility library for Unity. It contains several helpful extension methods, Tools helper classes, along with some basic Unity engine functionality classes.

## Minimum Requirements
* **Unity Version:** 2021.3.X or Higher
* **Scripting Runtime**: .Net 4.X

## Installing JCMG Utility
Using this library in your project can be done in three ways:

### Install via OpenUPM
The package is available on the [openupm registry](https://openupm.com/). It's recommended to install it via [openupm-cli](https://github.com/openupm/openupm-cli).

```
openupm add com.jeffcampbellmakesgames.jcmg-utility
```

### Install via GIT URL
Using the native Unity Package Manager introduced in 2017.2, you can add this library as a package by modifying your `manifest.json` file found at `/ProjectName/Packages/manifest.json` to include it as a dependency. See the example below on how to reference it.

```
{
	"dependencies": {
		...
		"com.jeffcampbellmakesgames.jcmg-utility" : "https://github.com/jeffcampbellmakesgames/jcmg-utility.git#release/stable",
		...
	}
}
```


You will need to have Git installed and available in your system's PATH.

## Support
If this is useful to you and/or you’d like to see future development and more tools in the future, please consider supporting it either by contributing to the Github projects (submitting bug reports or features and/or creating pull requests) or by buying me coffee using any of the links below. Every little bit helps!

[![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/I3I2W7GX)

## Contributing

For information on how to contribute and code style guidelines, please visit [here](CONTRIBUTING.md).
