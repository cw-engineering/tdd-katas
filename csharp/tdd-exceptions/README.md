# C# Exceptions Kata

_TDD kata with NUnit and Shouldly._

## Introduction

You work for a company that processes billing information. Your team works on a parser that can read X12 files. You were assigned a task to write an exception that reports parsing errors.

You used TDD and wrote tests and code based on the requirements and provided the implementation to other team members. When they tried to use it, they found multiple issues.

### Requirements

The exception must:

 * Capture **line**, **column** and **file position** (offset)
 * Be serializable to binary, XML and JSON format
 * JSON must conform to attached **schema.json** file

### Fix the following issues

 1. Binary serialization does not work.
 2. JSON is not not valid according to the schema file.
 3. XML serialization does not work.

### Goal

Your goal is to update the code (using TDD) to fix all the above issues.