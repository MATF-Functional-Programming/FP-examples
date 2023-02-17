import org.apache.spark.SparkConf
import org.apache.spark.SparkContext
import org.apache.spark.rdd.RDD._

object WordCountSpark {

   def main(args: Array[String]){

      val konf = new SparkConf()
        .setAppName("WordCount")
        .setMaster("local[4]")

      val sk = new SparkContext(konf)

      val rdd = sk.textFile("input.txt")

      knjigaRDD.flatMap(_.split(" "))
               .map(rec => (rec , 1))
               .reduceByKey((_+_))
               .sortByKey()
               .saveAsTextFile("output.txt")

      sk.stop()
  }
}
