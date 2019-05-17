package com.craneware.tdd.coding;

public class JavaCodeMetrics {

    public static int countLines(String code) {

        if(code == null || code.length() == 0){
            return 0;
        }

        if (code.contains("*/") && code.contains("*/")) {
            code = code.replace(code.substring
                            (code.indexOf("/*"), code.indexOf("*/"))
                    , "");
        }

        String[] acc = code.split("\n");

        int count=0;
        for (int i=0; i<acc.length;i++ ){

            if (acc[i].startsWith("import") || acc[i].startsWith("package")) ;
            else if (acc[i].trim().length() == 0 ) ;
            else if (acc[i].trim().startsWith("//"));
            else if (acc[i].trim().startsWith("/*"));
            else if(acc[i].trim().endsWith("*/"));
            else
            {
                count++;
            }

        }
        return count;
    }
}
