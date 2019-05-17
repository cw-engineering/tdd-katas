import { Calculator } from './calculator';

describe('Calculator', () => {

    describe('add', () => {

        it('should return zero when input is empty string or spaces', () => {
            const result = Calculator.add(' ');
            expect(result).toEqual(0);
        });

    });

});
