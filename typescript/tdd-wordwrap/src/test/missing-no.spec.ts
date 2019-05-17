import { MissingNo } from '../lib/missing-no';

describe('Wordwrap', () => {

    // it('should find missing number (I)', () => {
    //     const numbers = [1, 2, 3, 4, 6, 7, 8, 9];
    //     const number = MissingNo.find(numbers);
    //     expect(number).toBe(5);
    // });

    // it('should find missing number (II)', () => {
    //     const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16];
    //     const number = MissingNo.find(numbers);
    //     expect(number).toBe(9);
    // });

    // it('should find missing number (III)', () => {
    //     const numbers = [1, 2, 3, 4, 6];
    //     const number = MissingNo.find(numbers);
    //     expect(number).toBe(5);
    // });

    // it('should find missing number (IV)', () => {
    //     const numbers = [1, 3, 4, 5, 6, 7, 8, 9];
    //     const number = MissingNo.find(numbers);
    //     expect(number).toBe(2);
    // });

    it('should find missing number (IV)', () => {
        const count = 11_125_084;
        const missing = count - 32;
        const numbers: number[] = [];

        for (let i = 1; i < count; i++) {
            if (i !== missing) {
                numbers.push(i);
            }
        }

        const number = MissingNo.find(numbers);

        expect(number).toBe(missing);
    });

    it('should find missing number (V)', () => {
        const count = 11_125_084;
        const missing = count - 32;
        const numbers: number[] = [];

        for (let i = 1; i < count; i++) {
            if (i !== missing) {
                numbers.push(i);
            }
        }

        const number = MissingNo.find2(numbers);

        expect(number).toBe(missing);
    });

});