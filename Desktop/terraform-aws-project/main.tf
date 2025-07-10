provider "aws" {
  region = var.region
}

resource "aws_instance" "ec2" {
  ami           = var.ami_id
  instance_type = var.instance_type

  tags = {
    Name = "TerraformEC2"
  }
}

resource "aws_s3_bucket" "bucket" {
  bucket = var.bucket_name
  force_destroy = true
}

resource "aws_iam_user" "s3_user" {
  name = "s3-read-user"
}

resource "aws_iam_user_policy" "read_only_policy" {
  name = "S3ReadOnlyPolicy"
  user = aws_iam_user.s3_user.name

  policy = jsonencode({
    Version = "2012-10-17",
    Statement = [{
      Effect   = "Allow",
      Action   = ["s3:GetObject"],
      Resource = ["${aws_s3_bucket.bucket.arn}/*"]
    }]
  })
}
