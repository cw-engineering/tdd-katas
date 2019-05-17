export interface Logger {
    log(message?: any, ...params: any[]): void;
}

export function log(logger?: Logger) {
    return function(target: any, methodName: string, descriptor: PropertyDescriptor) {
        if (logger !== void 0) {
            const origFn: Function = descriptor.value;
            descriptor.value = function() {
                const args = Array.from(arguments);
                logger.log(methodName, ...args);
            };
        }
    };
}
