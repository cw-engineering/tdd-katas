import { log, Logger } from './log';

describe('log', () => {

    it('should implement factory pattern and return a function', () => {
        const result = log();

        expect(result).toBeInstanceOf(Function);
    });

    it('should use custom logger', () => {
        let logCalled = false;
        const customLogger: Logger = {
            log: function(msg: string) {
                logCalled = true;
            }
        };

        class TestClass {
            @log(customLogger)
            foo() { }
        }

        new TestClass().foo();

        expect(logCalled).toBeTruthy();
    });

    it('should log the method name the decorator is attached to', () => {
        let message = '';
        const customLogger: Logger = {
            log: function(msg: string) {
                message = msg;
            }
        };

        class TestClass {
            @log(customLogger)
            foo() { }
        }

        new TestClass().foo();

        expect(message).toContain('foo');
    });

    it('should log the method argument the decorator is attached to', () => {
        let argument: any[] = [];
        const customLogger: Logger = {
            log: function(msg: string, ...params: any[]) {
                 argument = params;
            }
        };

        class TestClass {
            @log(customLogger)
            foo(arg1: number) { }
        }

        new TestClass().foo(1234);

        expect(argument[0]).toBe(1234);
    });

    it('should log the method arguments the decorator is attached to', () => {
        let argument: any[] = [];
        const customLogger: Logger = {
            log: function(msg: string, ...params: any[]) {
                 argument = params;
            }
        };

        class TestClass {
            @log(customLogger)
            foo(arg1: number, arg2: string) { }
        }

        new TestClass().foo(1234, 'test');

        expect(argument[1]).toBe('test');
    });

    it('should log the method arguments the decorator is attached to', () => {
        let argument: any[] = [];
        const customLogger: Logger = {
            log: function(msg: string, ...params: any[]) {
                 argument = params;
            }
        };

        class TestClass {
            @log(customLogger)
            foo(arg1: number, arg2: string) { }
        }

        new TestClass().foo(12345, 'test1');

        expect(argument).toEqual([12345, 'test1']);
    });

});
