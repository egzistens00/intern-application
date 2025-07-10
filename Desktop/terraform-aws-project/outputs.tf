output "ec2_ip" {
  value = aws_instance.ec2.public_ip
}

output "bucket_name" {
  value = aws_s3_bucket.bucket.id
}
