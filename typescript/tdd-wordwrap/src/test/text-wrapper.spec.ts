import { TextWrapper } from '../lib/text-wrapper';

describe('Wordwrap', () => {

    describe('wrapLine', () => {

        it('wraps line after first word with 5 characters when limit is 5', () => {
            const result = TextWrapper.wrap('hello world', 5);
            expect(result).toBe('hello\nworld');
        });

        it('returns an empty string when an empty sting is passed in', () => {
            const result = TextWrapper.wrap('', 5);
            expect(result).toBe('');
        });

        it('wraps line when words are separated with tab', () => {
            const result = TextWrapper.wrap('hello\tRober', 5);
            expect(result).toBe('hello\nRober');  
        });

        it('wraps long words at end of text', () => {
            const result = TextWrapper.wrap('hello\tRoberto', 5);
            expect(result).toBe('hello\nRober\nto');  
        });

        it('wraps long words into multiple lines', () => {
            const result = TextWrapper.wrap('RobertoRobertoRobertoRoberto', 7);
            expect(result).toBe('Roberto\nRoberto\nRoberto\nRoberto'); 
        });

        it('ignores multiple spaces', () => {
            const result = TextWrapper.wrap('Roberto   Roberto   Roberto    Roberto', 8);
            expect(result).toBe('Roberto\nRoberto\nRoberto\nRoberto'); 
        });

        it('splits the text with long word on multiple lines', () => {
            const line1 = 'lorem ipsum dolorit sit amet blah blah';
            const line2 = 'hello world dolorit abcedfsh blah blah';
            const line3 = 'kldghfsdgfhzkghldzfskghdfghkjdfghlsdgf_kjhxldfkjgh';
            const text = line1 + ' ' + line2 + ' ' + line3;
            const expectedText = line1 + '\n' + line2 + '\n'
                        + 'kldghfsdgfhzkghldzfskghdfghkjdfghlsdgf' + '\n'
                        + '_kjhxldfkjgh';
            const result = TextWrapper.wrap(text, line1.length);

            expect(result).toBe(expectedText);
        });
    });
});
