import { Results } from './results';
export class Numbers {
    static isJumporion(input: number): Results {
        const digits: string = input.toString();
        if (input === 0) {
            return Results.NO;
        }

        if (digits.length <= 1) {
            return Results.YES;
        }

        for (let i = 0; i < digits.length - 1; i++) {
            const formerDigit: number = parseInt(digits[i], 10);
            const latterDigit: number = parseInt(digits[i + 1], 10);
            const difference = latterDigit - formerDigit;

            if (Math.abs(difference) !== 1) {
                return Results.NO;
            }
        }
        return Results.YES;
    }

    public static isTidyJumporion (input: number): Results {
        const digits = input.toString();
        if (this.isJumporion(input) === Results.YES) {
            const sortedDigits = Array.from(digits).sort().join('');
            if (sortedDigits === digits) {
                return Results.TIDY;
            }
            return Results.YES;
        }
        return Results.NO;
    }




}
