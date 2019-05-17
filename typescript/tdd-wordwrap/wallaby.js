module.exports = function () {
    return {
        env: { type: 'node' },
        debug: true,
        testFramework: 'jasmine',
        files: [
            'src/lib/*.ts'
        ],
        tests: [
            'src/test/*.spec.ts'
        ]
    };
};