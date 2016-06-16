
#Read Json Data

library(jsonlite)
inputData <- fromJSON("output10json.txt")


#Create Data Frame
outputdata <- data.frame(matrix(nrow=0,ncol=8))
colnames(outputdata) <- c("Text","Label", "Position_top", "Position_left", "Size_height", "Size_width", "Line_No") 

Line_number = 1
for (words in inputData$Regions$Lines[[1]]$Words)
{
        l <- length(words$Text)
       for (len in 1:l)
       {
               newRow <- data.frame(Text = words$Text[len],Position_top = words$Rectangle$Top[len] , Position_left= words$Rectangle$Left[len] , Size_height = words$Rectangle$Height[len], Size_width = words$Rectangle$Width[len], Label = "", Line_No = Line_number )
               
               
               #Check Email Address Format
               if(length(grep("(@)",newRow$Text)) > 0 )
               {
                       newRow$Label <- "Email Address"
               }
               if(length(grep("^\\s*(?:\\+?(\\d{1,3}))?[-. (]*(\\d{3})[-. )]*(\\d{3})[-. ]*(\\d{4})(?: *x(\\d+))?\\s*$",newRow$Text)) > 0)
               {
                       newRow$Label <- "Phone Number" 
               }
                       
               outputdata <- rbind(outputdata,data.frame(newRow))
       }
        Line_number <- Line_number + 1
}
#Base Region top left corner to 0,0 and adjust each word position accordingly
outputdata$Position_top <- outputdata$Position_top - inputData$Regions$Rectangle$Top
outputdata$Position_left <- outputdata$Position_left - inputData$Regions$Rectangle$Left

#Scale Height and Width to 100:60
outputdata$Size_height <- outputdata$Size_height / (inputData$Regions$Rectangle$Height/60)
outputdata$Size_width <- outputdata$Size_width / (inputData$Regions$Rectangle$Width/100)

outputdata$Position_top <- outputdata$Position_top / (inputData$Regions$Rectangle$Height/60)
outputdata$Position_left <- outputdata$Position_left / (inputData$Regions$Rectangle$Width/100)


