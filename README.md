# Run C# Tests on HyperExecute with TestMu AI (Formerly LambdaTest)

<p align="center">
  <a href="https://www.testmuai.com/"><img src="https://img.shields.io/badge/MADE%20BY%20TestMu%20AI-000000.svg?style=for-the-badge&labelColor=000" alt="Made by TestMu AI"></a>
  <a href="https://www.nuget.org/packages/NUnit/"><img src="https://img.shields.io/nuget/v/NUnit.svg?style=for-the-badge&labelColor=000000" alt="NUnit version"></a>
  <a href="https://community.testmuai.com/"><img src="https://img.shields.io/badge/Join%20the%20community-blueviolet.svg?style=for-the-badge&labelColor=000000" alt="Community"></a>
</p>

## Getting Started

[TestMu AI](https://www.testmuai.com/) (Formerly LambdaTest) is the world's first full-stack AI Agentic Quality Engineering platform that empowers teams to test intelligently, smarter, and ship faster. Built for scale, it offers a full-stack testing cloud with 10K+ real devices and 3,000+ browsers. With AI-native test management, MCP servers, and agent-based automation, TestMu AI supports Selenium, Appium, Playwright, and all major frameworks.

With TestMu AI (Formerly LambdaTest), you can run C# NUnit Selenium tests at scale on the HyperExecute smart test orchestration platform. This sample shows how to configure and execute C# tests using both Matrix and Auto-Split strategies on the TestMu AI cloud.

- [Sign up on TestMu AI](https://www.testmuai.com/register/) (Formerly LambdaTest).
- Follow the [TestMu AI documentation](https://www.testmuai.com/support/docs/) (Formerly LambdaTest) for the full setup walkthrough.

### Prerequisites

- .NET SDK 6.0 or later (the project targets `net6.0` deliberately — this sample
  exercises HyperExecute's older-runtime compatibility; see the
  [nunit-selenium sample](https://github.com/LambdaTest/nunit-selenium-hyperexecute-sample)
  for current net8.0)
- A TestMu AI (Formerly LambdaTest) account with HyperExecute access

Download the HyperExecute CLI binary corresponding to the host operating system. It is recommended to download the binary in the project's parent directory.

* Mac: https://downloads.lambdatest.com/hyperexecute/darwin/hyperexecute
* Linux: https://downloads.lambdatest.com/hyperexecute/linux/hyperexecute
* Windows: https://downloads.lambdatest.com/hyperexecute/windows/hyperexecute.exe

### Setup

Clone the repository:

```bash
git clone https://github.com/LambdaTest/hypertest-c-sharp-demo.git
cd hypertest-c-sharp-demo
```

Set your credentials as environment variables.

**macOS / Linux:**

```bash
export LT_USERNAME="YOUR_USERNAME"
export LT_ACCESS_KEY="YOUR_ACCESS_KEY"
```

**Windows:**

```bash
set LT_USERNAME="YOUR_USERNAME"
set LT_ACCESS_KEY="YOUR_ACCESS_KEY"
```

## Running C# Tests with Remote Test Discovery (v0.2)

The config (`yaml/hyperexecute_remote_v2.yaml`) uses HyperExecute's framework-based
remote test discovery: HyperExecute's .NET runner discovers the NUnit tests from
the built assembly on the worker — no separate discoverer project, grep command,
or `testRunnerCommand` needed.

```yaml
---
version: "0.2"
runson: linux

autosplit: true
concurrency: 5

pre:
  - dotnet build HyperTestDemos.sln -c Release

framework:
  name: dotnet/nunit
  discoveryMode: remote   # dotnet/* runners are remote-discovery only
  discoveryType: class    # one shard per test class (10 classes); use method for per-test shards
  # single-project repo: the runner locates the csproj and built assembly itself;
  # multi-project repos pass flags: [--project, <path-to-csproj>]
```

With `discoveryType: class`, HyperExecute discovers the 10 checkout test classes
and auto-splits them across 5 concurrent workers. Switch to `discoveryType: method`
to shard at individual test level (100 tests).

### Run tests

```bash
./hyperexecute --user $LT_USERNAME --key $LT_ACCESS_KEY --config yaml/hyperexecute_remote_v2.yaml
```

Visit the [HyperExecute Dashboard](https://hyperexecute.lambdatest.com/hyperexecute) to check the status of execution.

View results on your TestMu AI dashboard.

## Contributions

Contributions are welcome. Open an issue to discuss your idea before submitting a pull request. When reporting bugs, include your .NET version, OS, and NUnit version.

## TestMu AI (Formerly LambdaTest) Community

Connect with testers and developers in the [TestMu AI Community](https://community.testmuai.com/). Ask questions, share what you are building, and discuss best practices in test automation and DevOps.

## TestMu AI (Formerly LambdaTest) Certifications

Earn free [TestMu AI Certifications](https://www.testmuai.com/certifications/) for testers, developers, and QA engineers. Validate your skills in Selenium, Cypress, Playwright, Appium, Espresso and more. Industry-recognized, shareable on LinkedIn, and built by practitioners, not marketers.

## Learning Resources by TestMu AI (Formerly LambdaTest)

Learn modern testing through tutorials, guides, videos, and weekly updates:

* [TestMu AI Blog](https://www.testmuai.com/blog/)
* [TestMu AI Learning Hub](https://www.testmuai.com/learning-hub/)
* [TestMu AI on YouTube](https://www.youtube.com/@TestMuAI)
* [TestMu AI Newsletter](https://www.testmuai.com/newsletter/)

## LambdaTest is Now TestMu AI

On **January 12, 2026**, [LambdaTest evolved to TestMu AI](https://www.testmuai.com/lambdatest-is-now-testmuai/), the world's first fully autonomous **Agentic AI Quality Engineering Platform**.

Same team. Same infrastructure. Same customer accounts. All existing LambdaTest logins, scripts, capabilities, and integrations continue to work without change.

Find the new home for [LambdaTest](https://www.testmuai.com).

### How LambdaTest Evolved into TestMu AI

In 2017, we launched LambdaTest with a simple mission: make testing fast, reliable, and accessible. As LambdaTest grew, we expanded into Test Intelligence, Visual Regression Testing, Accessibility Testing, API Testing, and Performance Testing, covering the full depth of the testing lifecycle.

As software development entered the AI era, testing had to evolve, too. We rebuilt the architecture to be AI-native from the ground up, with autonomous agents that **plan, author, execute, analyze, and optimize tests** while keeping humans in the loop. The platform integrates with your repos, CI, IDEs, and terminals, continuously learning from every code change and development signal.

That evolution earned a new name: **TestMu AI**, built for an AI-first future of quality engineering. TestMu is not a new name for us. It is the name of our annual community conference, which has brought together 100,000+ quality engineers to discuss how AI would reshape testing, long before that became an industry norm.

What started as a high-performance cloud testing platform has transformed into an AI-native, multi-agent system powering a connected, end-to-end quality layer. That evolution defined a new identity: LambdaTest evolved into TestMu AI, built for an AI-first future of quality engineering.

## Support

Got a question? Email [support@testmuai.com](mailto:support@testmuai.com) or chat with us 24x7 from our chat portal.
