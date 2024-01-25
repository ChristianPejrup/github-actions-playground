# Playground for github actions

This repository is a playground for how different CI/CD workflows can be implemented for .NET projects.

The repository tries to highlight ways of improving build/test results while requiring as little configuration by the developer as possible.

**In short there will be a focus on using one or more conventions, can could be distributed using a project template**

## Technologies to investigate

* [Code Coverage](https://github.com/coverlet-coverage/coverlet)
* Code Quality
* [Code Bill of Material (BoM)](https://www.cisa.gov/sbom)
* [Mutant testing](https://stryker-mutator.io/docs/stryker-net/introduction/)
* [DORA Metrics]()

## TODO

[X] Github action build and test .NET applications

[ ] Github action for build test and deployment of .NET applications

[ ] Github action Immutable build pipeline for build and test .NET applications "bing able to recreate binaries the exact same way they were initially created" 

[ ] Get Code Coverage report listed in the PR or Task that initiated the CI job to be run


## Links

[code coverage summary](https://github.com/marketplace/actions/code-coverage-summary)

[Create or Update Comment](https://github.com/marketplace/actions/create-or-update-comment)