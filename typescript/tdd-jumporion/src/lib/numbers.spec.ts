import { Numbers } from './numbers';

describe('Numbers', () => {
    describe('isJumporion()', () => {
        it('should return empty string for isJumporion(0)', () => {
            const result: string = Numbers.isJumporion(0);

            expect(result).toBe('NO');
        });

        it('should return "YES" if sinle digit', () => {
            const result: string = Numbers.isJumporion(1);

            expect(result).toBe('YES');
        });

        it('should return NO if number is not a jumporion', () => {
            const result: string = Numbers.isJumporion(18);

            expect(result).toBe('NO');
        });

        it('should return YES if number is a jumporion', () => {
            const result: string = Numbers.isJumporion(12);

            expect(result).toBe('YES');
        });
        it('should return YES if number is a jumporion', () => {
            const result: string = Numbers.isJumporion(123);

            expect(result).toBe('YES');
        });

        it('should return YES if number is a jumporion', () => {
            const result: string = Numbers.isJumporion(321);

            expect(result).toBe('YES');
        });

        it('should return YES if number is a jumporion', () => {
            const result: string = Numbers.isJumporion(890);

            expect(result).toBe('NO');
        });

        it('should return YES if number is a jumporion', () => {
            const result: string = Numbers.isJumporion(101);

            expect(result).toBe('YES');
        });

        it('should return NO if number is NaN', () => {
            const result: string = Numbers.isJumporion(NaN);

            expect(result).toBe('NO');
        });

        it('should return TIDY if number is tidy jumporion', () => {
            const result: string = Numbers.isTidyJumporion(123);

            expect(result).toBe('TIDY');
        });
        it('should return NO if number is not jumporion', () => {
            const result: string = Numbers.isTidyJumporion(19);

            expect(result).toBe('NO');
        });
        it('should return yes if number is jumporion but not tidy', () => {
            const result: string = Numbers.isTidyJumporion(121);

            expect(result).toBe('YES');
        });
        it('should return yes if number is jumporion but not tidy', () => {
            const result: string = Numbers.isTidyJumporion(4323210121);

            expect(result).toBe('YES');
        });
        it('should return no for infinity', () => {
            const result: string = Numbers.isTidyJumporion(Infinity);

            expect(result).toBe('NO');
        });
        it('should return yes if number is jumporion but not tidy', () => {
            const result: string = Numbers.isTidyJumporion(1.2345);

            expect(result).toBe('NO');
        });
        it('should return yes if number is jumporion but not tidy', () => {
            const result: string = Numbers.isTidyJumporion(-1);

            expect(result).toBe('NO');
        });
        it('should return yes if number is jumporion but not tidy', () => {
            const result: string = Numbers.isTidyJumporion(-1.123);

            expect(result).toBe('NO');
        });
        it('should return yes if number is jumporion but not tidy', () => {
            const result: string = Numbers.isTidyJumporion(10);

            expect(result).toBe('YES');
        });
        it('should return yes if number is jumporion but not tidy', () => {
            const result: string = Numbers.isTidyJumporion(0x24);

            expect(result).toBe('NO');
        });
    });
});
