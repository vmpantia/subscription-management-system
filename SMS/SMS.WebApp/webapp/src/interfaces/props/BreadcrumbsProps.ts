export interface BreadcrumbsProps {
    pages : BreadcrumbsPage[]
}

export interface BreadcrumbsPage {
    link:string | null,
    name:string
}