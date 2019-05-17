import { DiscountCalculator, UserDetails } from './calculator';

describe('DiscountCalculator', () => {

    let calculator: DiscountCalculator;

    beforeEach(() => {
        calculator = new DiscountCalculator();
    });

    describe('calculate', () => {

        it('should return the original price when no user details provided', () => {
            const originalPrice = 100;
            const result = calculator.calculate(originalPrice);
            expect(result).toBe(originalPrice);
        });

        it('should return the original price when no user details provided (2)', () => {
            const originalPrice = 80;
            const result = calculator.calculate(originalPrice);
            expect(result).toBe(originalPrice);
        });

        it('should return a new 1% discounted price when a user have 1 year loaylty discount', () => {
            const oroginalPrice = 100;
            const user: UserDetails = {
                yearsRegistered : 1,
                userType: 'potato'
            };
            const result = calculator.calculate(oroginalPrice, user);
            expect(result).toBe(99);
        });

        it('should return no more than a 5% discount for a potato user registed for >5 years', () => {
            const user: UserDetails = {
                yearsRegistered: 7,
                userType: 'potato'
            };
            const originalPrice = 100;

            const result = calculator.calculate(originalPrice, user);

            expect(result).toBe(95);
        });

        it('should return 2% for account type and max 5% for years registered discount for a bronze user registed for >5 years', () => {
            const user: UserDetails = {
                yearsRegistered: 7,
                userType: 'bronze'
            };
            const originalPrice = 100;

            const result = calculator.calculate(originalPrice, user);

            expect(result).toBe(93);
        });

        it('should return 4% for silver account type 0 years registered', () => {
            const user: UserDetails = {
                yearsRegistered: 0,
                userType: 'silver'
            };
            const originalPrice = 100;

            const result = calculator.calculate(originalPrice, user);

            expect(result).toBe(96);
        });

        it('should return 7% discount for gold account with 0 years registered', () => {
            const user: UserDetails = {
                yearsRegistered: 0,
                userType: 'gold'
            };
            const originalPrice = 100;

            const result = calculator.calculate(originalPrice, user);

            expect(result).toBe(93);
        });

        [50, 100, 120, 140, 150].forEach((price) => {
            it('should return correct 5 year discount for original price of ' + price, () => {
                const user: UserDetails = {
                    yearsRegistered: 5,
                    userType: 'potato'
                };

                const result = calculator.calculate(price, user);

                expect(result).toBe( price * 0.95);
            });
        });

        it('should throw an error if the years registered is -1', () => {
            const originalPrice = 100;
            const user: UserDetails = {
                yearsRegistered : -1,
                userType: 'potato'
            };
            const action = () => calculator.calculate(originalPrice, user);
            expect(action).toThrowError('Bad luck!');
        });
    });
});
