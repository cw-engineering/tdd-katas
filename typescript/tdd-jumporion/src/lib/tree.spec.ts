import { Node, Tree } from './tree';

describe('Tree', () => {

    it('should return true when root is undefined', () => {

        const result = Tree.IsUnique(undefined);

        expect(result).toBe(true);
    });

    it('should return true when root is null', () => {

        const result = Tree.IsUnique(null);

        expect(result).toBe(true);
    });

    it('should return true when single node', () => {

        const node: Node = {
            name: 'abla'
        };

        const result = Tree.IsUnique(node);

        expect(result).toBe(true);
    });

    it('should return true when multiple nodes', () => {

        const node: Node = {
            name: 'abla',
            left: { name: 'zeze' },
            right: { name: 'budu' }
        };

        const height = { max: 0 };
        const result = Tree.IsUnique(node, height);

        expect(result).toBe(true);
        expect(height.max).toBe(2);
    });

    it('should return false when not unique', () => {

        const node: Node = {
            name: 'abla',
            left: { name: 'zeze' },
            right: {
                name: 'budu',
                right: {
                    name: 'lele',
                    left: {
                        name: 'zeze'
                    }
                }
            }
        };

        const height = { max: 0 };
        const result = Tree.IsUnique(node, height);

        expect(result).toBe(false);
        expect(height.max).toBe(4);
    });

});
