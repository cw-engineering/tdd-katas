export class Board {

    generate(width: Number, height: Number): String[][] {
        const board = new Array();
        for (let i = 0; i < height; i++) {
            board.push(new Array(width));
            for (let j = 0; j < width; j++) {
                board[i][j] = '';
            }
        }

        return board;
    }

    populate(generatedBoard: String[][], numberOfBombs: number): any {
        const height = generatedBoard.length;
        const width = generatedBoard[0].length;
        const maxBombs = height * width;

        if (numberOfBombs > maxBombs) { throw 'Too many bombs'; }
        if (numberOfBombs < 1) { throw 'One bomb required'; }

        const random = (range: number) => {
            range--;
            const d = Math.round(Math.random() * range);
            return d;
        };

        while (numberOfBombs > 0) {
            const x = random(width);
            const y = random(height);
            if (generatedBoard[y][x] === 'x') { continue; }
            generatedBoard[y][x] = 'x';
            numberOfBombs--;
        }

        return generatedBoard;
    }

}
