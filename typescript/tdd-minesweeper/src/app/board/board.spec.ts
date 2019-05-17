import { Board } from './board';

describe('Board', () => {

    describe('generate', () => {
        it('should generate the board as an array', () => {
            const board = new Board();
            const generatedBoard = board.generate(2, 2);

            expect(generatedBoard instanceof Array).toBeTruthy();
        });

        it ('should generate the board as an array with correct width', () => {
            const board  = new Board();
            const generatedBoard = board.generate(2, 2);

            expect(generatedBoard[0].length).toEqual(2);
        });

        it ('should generate the board as an array with correct height', () => {
            const board  = new Board();
            const generatedBoard = board.generate(2, 2);

            expect(generatedBoard.length).toEqual(2);
        });

        it ('should generate the board with any height', () => {
            const board = new Board();
            const generatedBoard = board.generate(2, 7);

            expect(generatedBoard.length).toEqual(7);
        });

        it ('should generate the board with any width', () => {
            const board = new Board();
            const generatedBoard = board.generate(3, 7);

            expect(generatedBoard[2].length).toEqual(3);
        });

        it ('should generate the board with first value as the empty string', () => {
            const board = new Board();
            const generatedBoard = board.generate(3, 7);

            expect(generatedBoard[0][0]).toEqual('');
        });

        it ('should generate the board with all values as the empty string', () => {
            const board = new Board();
            const generatedBoard = board.generate(2, 2);

            expect(generatedBoard).toEqual([['', ''], ['', '']]);
        });
    });

    describe('populate', () => {
        it ('should return populated board of equal width', () => {
            const board = new Board();
            const generatedBoard = board.generate(8, 2);
            const populatedBoard  = board.populate(generatedBoard, 1);

            expect(populatedBoard[0].length).toEqual(8);
        });

        it ('should return populated board of equal height', () => {
            const board = new Board();
            const generatedBoard = board.generate(3, 6);
            const populatedBoard  = board.populate(generatedBoard, 1);

            expect(populatedBoard.length).toEqual(6);
        });

        it ('should not accept number of bombs greater than the board size', () => {
            const board = new Board();
            const generatedBoard = board.generate(1, 2);
            expect(() => board.populate(generatedBoard, 3)).toThrow('Too many bombs');
        });

        it ('should contain at least 1 bomb', () => {
            const board = new Board();
            const generatedBoard = board.generate(1, 2);
            expect(() => board.populate(generatedBoard, 0)).toThrow('One bomb required');
        });

        it ('should populate the board with the specified number of bombs', () => {
            const numberOfRequiredBombs = 7;
            const board = new Board();
            const generatedBoard = board.generate(4, 5);
            const populatedBoard  = board.populate(generatedBoard, numberOfRequiredBombs);

            const numberOfBombsOnBoard = populatedBoard
                .map(x => x.filter(y => y === 'x').length)
                .reduce((total, x) => total + x, 0);

            expect(numberOfBombsOnBoard).toEqual(numberOfRequiredBombs);
        });
    });

});
