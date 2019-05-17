
export class DiscountCalculator {

    calculate(originalPrice: number, user?: UserDetails): number {
        const userTypeDiscount = this.getUserTypeDiscount(user);
        const yearlyDiscount = this.getYearlyDiscount(user);

        const totalDiscount = userTypeDiscount + yearlyDiscount;

        const resultPrice = originalPrice * (100 - totalDiscount) / 100;

        return resultPrice;
    }

    private getYearlyDiscount(user: UserDetails | undefined): number {
        if (user === void 0) {
            return 0;
        }
        if (user.yearsRegistered < 0) {
            throw new Error('Bad luck!');
        }
        return Math.min(5, user.yearsRegistered);
    }

    private getUserTypeDiscount(user: UserDetails | undefined): number {
        const discounts = {
            'potato': 0,
            'bronze': 2,
            'silver': 4,
            'gold': 7
        };
        return (user === void 0) ? 0 : discounts[user.userType];
    }

}

export interface UserDetails {
    yearsRegistered: number;
    userType: 'potato'|'bronze'|'silver'|'gold';
}
