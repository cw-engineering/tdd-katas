
export class TextWrapper {

    public static wrap(text: string, columns: number): string {
        text = text.replace('\t', ' ').replace(/[\s]+/g, ' '); 
        const words: string[] = text.split(' '); 
        const goodWords: string[] = new Array<string>();
        let wrappedResult = '';

        words.forEach(word => {
            if (word.length > columns) {
                for (let i = 0; i < word.length / columns; i++) {
                    const wordToAdd = word.substr(i * columns, columns);
                    goodWords.push(wordToAdd);
                }
            } else {
                goodWords.push(word);
            }
        });
        console.log(goodWords); 
        wrappedResult = goodWords.join('\n');
        return wrappedResult; 
    }
}