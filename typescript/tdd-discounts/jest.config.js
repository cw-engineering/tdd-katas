module.exports = {
  "globals": {
    "ts-jest": {
      "tsConfig": "./tsconfig.json"
    }
  },
  "transform": {
    ".ts": "ts-jest"
  },
  "testEnvironment": "node",
  "testRegex": "\\.spec\\.ts$",
  "moduleFileExtensions": [
    "ts",
    "js"
  ],
  "collectCoverage": true,
  "collectCoverageFrom": [
    "**/src/lib/**/*.{ts}",
    "!**/node_modules/**"
  ]
};
