export interface Node {
    name: string;
    left?: Node;
    right?: Node;
}

export class Tree {

    static IsUnique(rootNode: Node | undefined | null, height?: { max: number }): boolean {

        const items: Array<{
            height: number,
            node: Node | undefined | null
        }> = [];
        const names: {
            [index: string]: boolean
        } = {};
        let isUnique = true;

        if (height !== void 0 && height !== null) {
            height.max = 0;
        }

        items.push({
            node: rootNode,
            height: 1
        });

        while (items.length > 0) {
            const item = items.pop();
            if (item === void 0 || item === null) {
                continue;
            }
            if (item.node === void 0 || item.node === null) {
                continue;
            }
            const name = item.node.name;
            if (names[name] === true) {
                isUnique = false;
            }
            if (height !== void 0 && height !== null) {
                height.max = Math.max(height.max, item.height);
            }
            names[name] = true;
            items.push({
                node: item.node.left,
                height: item.height + 1
            });
            items.push({
                node: item.node.right,
                height: item.height + 1
            });
        }

        return isUnique;
    }

}
