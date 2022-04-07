# Dofus Reverse Engineering Tools ♻️🥚 - 📁Repository

[![Conventional Commits](https://img.shields.io/badge/Commit%20Message%20Format-Conventional%20Commits%201.0.0-yellow.svg)](https://conventionalcommits.org)

[![Semver](https://img.shields.io/badge/Versioning-Semver%202.0.0-green)](https://semver.org/spec/v2.0.0.html)

[![Keep a Changelog v1.0.0 badge](https://img.shields.io/badge/Changelog-Keep%20a%20Changelog%201.0.0-%23E05735)](https://keepachangelog.com/en/1.0.0)

# Repository Structure 🧱

| Name                        | Description                                                                                                                    |
| --------------------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| `src`                       | All the code related to the project                                                                                            |
| `src/StumpR.Binary`         | Folder containing binary logic using for serialization / deserialization                                                       |
| `src/StumpR.Protocol`       | Folder containing Dofus protocol(v2.62) generated with ProtoBuilder tool                                                       |
| `tools/StumpR.GUI.Sniffer`  | Sniffer made with SharpPCap with interpretation of intercepted dofus packets(deserialization)                                  |
| `tools/StumpR.ProtoBuilder` | Protocol constructor using regular expressions to parse Dofus AS3 client source files and create Dofus network messages in C#. |
