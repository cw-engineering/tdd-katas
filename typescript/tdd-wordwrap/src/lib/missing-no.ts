
export class MissingNo {

    public static find(numbers: number[]): number {
        let mid = 0;
        let left = 0;
        let right = numbers.length;

        while (true) {
            const no = Math.ceil((left + right) / 2);
            if (no === mid) {
                return no;
            }
            mid = no;
            if (numbers[mid - 1] === mid) {
                left = mid;
            } else {
                right = mid;
            }
        }
    }

}